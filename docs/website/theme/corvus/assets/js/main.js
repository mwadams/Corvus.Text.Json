/**
 * Corvus.Text.Json Documentation Site — Main JavaScript
 */

document.addEventListener('DOMContentLoaded', () => {
  // Mobile navigation toggle
  const menuToggle = document.querySelector('.js-toggle-menu');
  const mobileNav = document.querySelector('.js-mobile-nav');

  if (menuToggle && mobileNav) {
    menuToggle.addEventListener('click', () => {
      const isOpen = mobileNav.classList.toggle('is-open');
      menuToggle.setAttribute('aria-expanded', isOpen ? 'true' : 'false');
    });
  }

  // Mobile sidebar drawer toggle
  const sidebarToggle = document.querySelector('.sidebar-toggle');
  const sidebar = document.querySelector('.sidebar');
  const backdrop = document.querySelector('.sidebar-backdrop');

  function closeSidebar() {
    sidebar?.classList.remove('is-open');
    backdrop?.classList.remove('is-visible');
    sidebarToggle?.setAttribute('aria-expanded', 'false');
  }

  if (sidebarToggle && sidebar) {
    sidebarToggle.addEventListener('click', () => {
      const opening = !sidebar.classList.contains('is-open');
      sidebar.classList.toggle('is-open');
      backdrop?.classList.toggle('is-visible');
      sidebarToggle.setAttribute('aria-expanded', opening ? 'true' : 'false');
    });

    backdrop?.addEventListener('click', closeSidebar);

    // Close drawer when any link inside the sidebar is clicked (mobile)
    sidebar.addEventListener('click', (e) => {
      if (e.target.closest('a') && window.innerWidth < 960) {
        closeSidebar();
      }
    });
  }

  // Sidebar collapsible sections (namespace headings)
  document.querySelectorAll('.sidebar__heading').forEach((toggle) => {
    toggle.addEventListener('click', () => {
      const section = toggle.closest('.sidebar__section');
      const body = section?.querySelector('.sidebar__body');
      if (body) {
        body.classList.toggle('is-collapsed');
        toggle.classList.toggle('is-collapsed');
      }
    });
  });

  // Sidebar collapsible member categories
  document.querySelectorAll('.sidebar__cat-toggle').forEach((toggle) => {
    toggle.addEventListener('click', () => {
      const body = toggle.nextElementSibling;
      if (body && body.classList.contains('sidebar__cat-body')) {
        body.classList.toggle('is-collapsed');
        toggle.classList.toggle('is-collapsed');
      }
    });
  });

  // Scroll active sidebar item into view after page load
  requestAnimationFrame(() => {
    const activeItem = document.querySelector('.sidebar__link.is-active, .sidebar__link--member.is-active');
    if (activeItem) {
      activeItem.scrollIntoView({ block: 'center', behavior: 'instant' });
    }
  });

  // Smooth scroll for anchor links
  document.querySelectorAll('a[href^="#"]').forEach((anchor) => {
    anchor.addEventListener('click', (e) => {
      const target = document.querySelector(anchor.getAttribute('href'));
      if (target) {
        e.preventDefault();
        target.scrollIntoView({ behavior: 'smooth', block: 'start' });
        history.pushState(null, '', anchor.getAttribute('href'));
      }
    });
  });

  // Copy code button
  document.querySelectorAll('pre code').forEach((block) => {
    const wrapper = block.parentElement;
    wrapper.classList.add('code-block');
    const button = document.createElement('button');
    button.className = 'code-block__copy';
    button.textContent = 'Copy';
    button.addEventListener('click', () => {
      navigator.clipboard.writeText(block.textContent).then(() => {
        button.textContent = 'Copied!';
        setTimeout(() => { button.textContent = 'Copy'; }, 2000);
      });
    });
    wrapper.appendChild(button);
  });

  // Mark active sidebar link
  const currentPath = window.location.pathname;
  document.querySelectorAll('.sidebar__link').forEach((link) => {
    if (link.getAttribute('href') === currentPath) {
      link.classList.add('is-active');
    }
  });

  // ── On-page TOC in sidebar ──────────────────────────────────────────────
  // For doc pages: extract h2 headings, insert as a sub-list under the
  // active sidebar link, and highlight the current section on scroll.
  // Skip when the sidebar has server-side member navigation (API pages).
  const hasMemberNav = document.querySelector('[data-has-member-nav]');
  const activeLink = document.querySelector('.sidebar__link.is-active');
  const docContent = document.querySelector('.doc__content');

  if (activeLink && docContent && !hasMemberNav) {
    const headings = docContent.querySelectorAll('h2[id]');
    if (headings.length > 1) {
      const subList = document.createElement('ul');
      subList.className = 'sidebar__sublist';

      headings.forEach((h) => {
        const li = document.createElement('li');
        li.className = 'sidebar__item sidebar__item--toc';
        const a = document.createElement('a');
        a.className = 'sidebar__link sidebar__link--toc';
        a.href = '#' + h.id;
        a.textContent = h.textContent;
        li.appendChild(a);
        subList.appendChild(li);
      });

      // Insert sub-list after the active link's parent <li>
      activeLink.closest('.sidebar__item').appendChild(subList);

      // Scroll-spy: highlight the heading nearest the top of the viewport.
      // Uses a scroll listener (throttled via rAF) instead of
      // IntersectionObserver so clicks that land the heading at the very
      // top are always detected.
      const tocLinks = subList.querySelectorAll('.sidebar__link--toc');
      const headingArr = Array.from(headings);
      let ticking = false;

      function updateActiveToc() {
        const scrollY = window.scrollY;
        const offset = 100; // px below top to count as "current"
        let current = headingArr[0];

        for (const h of headingArr) {
          if (h.getBoundingClientRect().top <= offset) {
            current = h;
          } else {
            break;
          }
        }

        tocLinks.forEach((l) => l.classList.remove('is-current'));
        if (current) {
          const match = subList.querySelector(`a[href="#${current.id}"]`);
          if (match) {
            match.classList.add('is-current');
            // Scroll the sidebar so the active TOC item stays visible
            match.scrollIntoView({ block: 'nearest', behavior: 'smooth' });
          }
        }
        ticking = false;
      }

      window.addEventListener('scroll', () => {
        if (!ticking) {
          ticking = true;
          requestAnimationFrame(updateActiveToc);
        }
      }, { passive: true });

      // Initial highlight
      updateActiveToc();
    }
  }
});
