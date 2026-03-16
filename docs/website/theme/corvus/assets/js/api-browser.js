/**
 * API Browser — inline incremental search for the API Reference landing page.
 *
 * Follows the same pattern as the site-wide search (search.js / endjin.com):
 *   • Lazy-loads the shared /search-index.json on first interaction
 *   • Builds a Lunr.js index (same library loaded globally via CDN)
 *   • Renders results inline, grouped by namespace
 *
 * When the input is empty the default namespace card grid is shown.
 * While typing, results replace the card grid with matching API entries.
 */
(function () {
  'use strict';

  const input = document.getElementById('api-browser-input');
  const statusEl = document.getElementById('api-browser-status');
  const resultsEl = document.getElementById('api-browser-results');
  const defaultContent = document.getElementById('api-browser-default');

  if (!input || !resultsEl || !defaultContent) return;

  let searchIndex = null;
  let searchDataMap = null;
  let indexLoading = false;

  // ── Index loading (shared /search-index.json, same as search.js) ──────────

  async function ensureIndex() {
    if (searchIndex || indexLoading) return;
    indexLoading = true;
    try {
      const resp = await fetch('/search-index.json');
      if (!resp.ok) throw new Error('HTTP ' + resp.status);
      const data = await resp.json();

      // Build a lookup map (keyed by url) and a Lunr index
      // Only index API entries (url starts with /api/)
      const apiEntries = data.filter(function (d) { return d.url && d.url.startsWith('/api/'); });

      searchDataMap = Object.create(null);
      apiEntries.forEach(function (doc) { searchDataMap[doc.url] = doc; });

      searchIndex = lunr(function () {
        this.ref('url');
        this.field('title',       { boost: 10 });
        this.field('keywords',    { boost: 8 });
        this.field('description', { boost: 5 });
        this.field('body');

        apiEntries.forEach(function (doc) { this.add(doc); }, this);
      });
    } catch (e) {
      console.warn('[api-browser] Failed to load search index:', e);
    } finally {
      indexLoading = false;
    }
  }

  // ── Helpers ────────────────────────────────────────────────────────────────

  function escapeHtml(str) {
    var el = document.createElement('span');
    el.textContent = str;
    return el.innerHTML;
  }

  function extractNamespace(keywords) {
    if (!keywords) return '';
    var parts = keywords.split(' ');
    for (var i = parts.length - 1; i >= 0; i--) {
      if (parts[i].indexOf('.') !== -1) return parts[i];
    }
    return '';
  }

  function extractKind(keywords) {
    if (!keywords) return '';
    var kinds = ['class', 'struct', 'interface', 'enum', 'delegate'];
    var lower = keywords.toLowerCase();
    for (var k = 0; k < kinds.length; k++) {
      if (lower.indexOf(' ' + kinds[k] + ' ') !== -1 || lower.indexOf(' ' + kinds[k]) !== -1) return kinds[k];
    }
    return '';
  }

  function isTypePage(doc) {
    return /\b(class|struct|interface|enum|delegate)\b/.test((doc.keywords || '').toLowerCase());
  }

  function truncate(str, max) {
    if (!str || str.length <= max) return str || '';
    return str.slice(0, max) + '\u2026';
  }

  // ── Search ─────────────────────────────────────────────────────────────────

  function performSearch(query) {
    if (!searchIndex) return;

    // Lunr wildcard search for partial matching (same as search.js)
    var results = searchIndex.search(query + '*');
    var maxResults = 50;

    if (results.length === 0) {
      statusEl.textContent = 'No results for \u201c' + query + '\u201d';
      resultsEl.innerHTML = '';
      return;
    }

    var hits = results.slice(0, maxResults).map(function (r) { return searchDataMap[r.ref]; }).filter(Boolean);

    statusEl.textContent = 'Showing ' + hits.length + ' result' + (hits.length !== 1 ? 's' : '') + ' for \u201c' + query + '\u201d';

    // Sort: type pages first, then alphabetical
    hits.sort(function (a, b) {
      var aType = isTypePage(a) ? 0 : 1;
      var bType = isTypePage(b) ? 0 : 1;
      if (aType !== bType) return aType - bType;
      return (a.title || '').localeCompare(b.title || '');
    });

    // Group by namespace
    var groups = new Map();
    hits.forEach(function (m) {
      var ns = extractNamespace(m.keywords) || 'Other';
      if (!groups.has(ns)) groups.set(ns, []);
      groups.get(ns).push(m);
    });

    var html = '';
    groups.forEach(function (items, ns) {
      html += '<div class="api-browser__group">';
      html += '<h3 class="api-browser__group-title">' + escapeHtml(ns) + '</h3>';
      html += '<ul class="api-browser__list">';

      items.forEach(function (item) {
        var kind = extractKind(item.keywords);
        var badgeClass = kind ? ' api__badge--' + kind : '';
        var badgeLabel = kind ? kind.charAt(0).toUpperCase() + kind.slice(1) : '';
        var desc = truncate(item.description, 120);

        html += '<li class="api-browser__item">';
        html += '<a class="api-browser__item-link" href="' + escapeHtml(item.url) + '">';
        html += '<span class="api-browser__item-name">' + escapeHtml(item.title) + '</span>';
        if (badgeLabel) {
          html += ' <span class="api__badge' + badgeClass + '">' + escapeHtml(badgeLabel) + '</span>';
        }
        if (desc) {
          html += '<span class="api-browser__item-desc">' + escapeHtml(desc) + '</span>';
        }
        html += '</a></li>';
      });

      html += '</ul></div>';
    });

    resultsEl.innerHTML = html;
  }

  // ── Event wiring (debounced input, same pattern as search.js) ─────────────

  var debounceTimer;
  input.addEventListener('input', function () {
    clearTimeout(debounceTimer);
    var q = input.value.trim();

    if (!q) {
      defaultContent.hidden = false;
      resultsEl.hidden = true;
      statusEl.textContent = '';
      resultsEl.innerHTML = '';
      return;
    }

    ensureIndex().then(function () {
      debounceTimer = setTimeout(function () {
        defaultContent.hidden = true;
        resultsEl.hidden = false;
        performSearch(q);
      }, 150);
    });
  });

  input.addEventListener('keydown', function (e) {
    if (e.key === 'Escape') {
      input.value = '';
      input.dispatchEvent(new Event('input'));
      input.blur();
    }
  });
})();
