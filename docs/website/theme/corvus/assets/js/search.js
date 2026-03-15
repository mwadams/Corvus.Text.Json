/**
 * Corvus.Text.Json Documentation Site — Lunr Search
 *
 * Provides incremental client-side search using a pre-built search-index.json
 * and the Lunr.js library loaded from CDN.
 *
 * Keyboard shortcut: Ctrl+K / Cmd+K to open, Escape to close.
 */

(function () {
  'use strict';

  let searchIndex = null;
  let searchData = null;
  let indexLoading = false;

  const searchInput = document.querySelector('.js-search-input');
  const searchOverlay = document.querySelector('.js-search-results-wrapper');
  const searchResultsList = document.getElementById('search-list');
  const searchNoResults = document.getElementById('search-no-results');
  const closeButtons = document.querySelectorAll('.js-search-overlay-close');

  if (!searchInput || !searchOverlay || !searchResultsList) return;

  // Build a lookup map once the data is loaded for O(1) access
  let searchDataMap = null;

  async function loadIndex() {
    if (searchIndex || indexLoading) return;
    indexLoading = true;

    try {
      const response = await fetch('/search-index.json');
      if (!response.ok) throw new Error(`HTTP ${response.status}`);
      searchData = await response.json();

      searchDataMap = Object.create(null);
      searchData.forEach((doc) => { searchDataMap[doc.url] = doc; });

      searchIndex = lunr(function () {
        this.ref('url');
        this.field('title', { boost: 10 });
        this.field('description', { boost: 5 });
        this.field('keywords', { boost: 8 });
        this.field('body');

        searchData.forEach((doc) => { this.add(doc); });
      });
    } catch (e) {
      console.warn('Search index not available:', e);
    } finally {
      indexLoading = false;
    }
  }

  function escapeHtml(str) {
    const el = document.createElement('span');
    el.textContent = str;
    return el.innerHTML;
  }

  function performSearch(query) {
    if (!searchIndex || !query || query.length < 2) {
      searchResultsList.innerHTML = '';
      if (searchNoResults) searchNoResults.hidden = true;
      return;
    }

    // Support partial-word matching with wildcard
    const results = searchIndex.search(query + '*');
    const maxResults = 20;

    if (results.length === 0) {
      searchResultsList.innerHTML = '';
      if (searchNoResults) searchNoResults.hidden = false;
      return;
    }

    if (searchNoResults) searchNoResults.hidden = true;

    const html = results.slice(0, maxResults).map((result) => {
      const doc = searchDataMap[result.ref];
      if (!doc) return '';

      const snippet = escapeHtml(doc.description || '');
      return `
        <a href="${escapeHtml(doc.url)}" class="search-results__item">
          <span class="search-results__title">${escapeHtml(doc.title)}</span>
          <span class="search-results__snippet">${snippet}</span>
          <span class="search-results__url">${escapeHtml(doc.url)}</span>
        </a>`;
    }).join('');

    searchResultsList.innerHTML = html;
  }

  function showSearch() {
    searchOverlay.hidden = false;
    searchInput.focus();
    loadIndex();
  }

  function hideSearch() {
    searchOverlay.hidden = true;
    searchInput.value = '';
    searchResultsList.innerHTML = '';
    if (searchNoResults) searchNoResults.hidden = true;
  }

  // Debounced input handler
  let debounceTimer;
  searchInput.addEventListener('input', () => {
    clearTimeout(debounceTimer);
    debounceTimer = setTimeout(() => {
      performSearch(searchInput.value.trim());
    }, 150);
  });

  searchInput.addEventListener('focus', () => {
    showSearch();
  });

  closeButtons.forEach((btn) => {
    btn.addEventListener('click', hideSearch);
  });

  // Keyboard shortcuts
  document.addEventListener('keydown', (e) => {
    if ((e.ctrlKey || e.metaKey) && e.key === 'k') {
      e.preventDefault();
      showSearch();
    }
    if (e.key === 'Escape') {
      hideSearch();
    }
  });
})();
