/**
 * API Browser — inline search/filter for the API Reference landing page.
 *
 * Lazy-loads /api/search-index.json on first keystroke and performs fast
 * case-insensitive substring matching against Title, Keywords, and Description.
 * Results are grouped by namespace and rendered inline, replacing the default
 * namespace card grid while a query is active.
 */
(function () {
  'use strict';

  const input = document.getElementById('api-browser-input');
  const status = document.getElementById('api-browser-status');
  const results = document.getElementById('api-browser-results');
  const defaultContent = document.getElementById('api-browser-default');

  if (!input || !results || !defaultContent) return;

  let indexData = null;
  let indexLoading = false;

  // ---- Data loading ----

  async function ensureIndex() {
    if (indexData || indexLoading) return;
    indexLoading = true;
    try {
      const resp = await fetch('/api/search-index.json');
      if (!resp.ok) throw new Error('HTTP ' + resp.status);
      indexData = await resp.json();
    } catch (e) {
      console.warn('[api-browser] Failed to load search index:', e);
    } finally {
      indexLoading = false;
    }
  }

  // ---- Helpers ----

  function escapeHtml(str) {
    const el = document.createElement('span');
    el.textContent = str;
    return el.innerHTML;
  }

  /** Extract namespace from the Keywords field, e.g. "JsonElement class Corvus.Text.Json" → "Corvus.Text.Json" */
  function extractNamespace(keywords) {
    if (!keywords) return '';
    const parts = keywords.split(' ');
    // The namespace is typically the last dot-separated token
    for (let i = parts.length - 1; i >= 0; i--) {
      if (parts[i].includes('.')) return parts[i];
    }
    return '';
  }

  /** Extract kind (class, struct, interface, enum, delegate) from the Keywords field */
  function extractKind(keywords) {
    if (!keywords) return '';
    const kinds = ['class', 'struct', 'interface', 'enum', 'delegate'];
    const lower = keywords.toLowerCase();
    for (const k of kinds) {
      if (lower.includes(' ' + k + ' ') || lower.includes(' ' + k)) return k;
    }
    return '';
  }

  /** True if this entry looks like a top-level type (not a member page) */
  function isTypePage(entry) {
    const kw = (entry.Keywords || '').toLowerCase();
    return /\b(class|struct|interface|enum|delegate)\b/.test(kw);
  }

  function truncate(str, max) {
    if (!str || str.length <= max) return str || '';
    return str.slice(0, max) + '…';
  }

  // ---- Search ----

  function search(query) {
    if (!indexData) return;

    const q = query.toLowerCase();
    const matches = [];

    for (const entry of indexData) {
      const haystack = ((entry.Title || '') + ' ' + (entry.Keywords || '') + ' ' + (entry.Description || '')).toLowerCase();
      if (haystack.includes(q)) {
        matches.push(entry);
      }
    }

    if (matches.length === 0) {
      status.textContent = 'No results for \u201c' + query + '\u201d';
      results.innerHTML = '';
      return;
    }

    status.textContent = 'Showing ' + matches.length + ' result' + (matches.length !== 1 ? 's' : '') + ' for \u201c' + query + '\u201d';

    // Sort: type pages first, then alphabetical
    matches.sort(function (a, b) {
      const aType = isTypePage(a) ? 0 : 1;
      const bType = isTypePage(b) ? 0 : 1;
      if (aType !== bType) return aType - bType;
      return (a.Title || '').localeCompare(b.Title || '');
    });

    // Group by namespace
    const groups = new Map();
    for (const m of matches) {
      const ns = extractNamespace(m.Keywords) || 'Other';
      if (!groups.has(ns)) groups.set(ns, []);
      groups.get(ns).push(m);
    }

    let html = '';
    for (const [ns, items] of groups) {
      html += '<div class="api-browser__group">';
      html += '<h3 class="api-browser__group-title">' + escapeHtml(ns) + '</h3>';
      html += '<ul class="api-browser__list">';

      for (const item of items) {
        const kind = extractKind(item.Keywords);
        const badgeClass = kind ? ' api__badge--' + kind : '';
        const badgeLabel = kind ? kind.charAt(0).toUpperCase() + kind.slice(1) : '';
        const desc = truncate(item.Description, 120);

        html += '<li class="api-browser__item">';
        html += '<a class="api-browser__item-link" href="' + escapeHtml(item.Url) + '">';
        html += '<span class="api-browser__item-name">' + escapeHtml(item.Title) + '</span>';
        if (badgeLabel) {
          html += ' <span class="api__badge' + badgeClass + '">' + escapeHtml(badgeLabel) + '</span>';
        }
        if (desc) {
          html += '<span class="api-browser__item-desc">' + escapeHtml(desc) + '</span>';
        }
        html += '</a></li>';
      }

      html += '</ul></div>';
    }

    results.innerHTML = html;
  }

  // ---- Event wiring ----

  let debounce;
  input.addEventListener('input', function () {
    clearTimeout(debounce);
    const q = input.value.trim();

    if (!q) {
      defaultContent.hidden = false;
      results.hidden = true;
      status.textContent = '';
      results.innerHTML = '';
      return;
    }

    ensureIndex().then(function () {
      debounce = setTimeout(function () {
        defaultContent.hidden = true;
        results.hidden = false;
        search(q);
      }, 150);
    });
  });

  // Clear button via Escape in the input
  input.addEventListener('keydown', function (e) {
    if (e.key === 'Escape') {
      input.value = '';
      input.dispatchEvent(new Event('input'));
      input.blur();
    }
  });
})();
