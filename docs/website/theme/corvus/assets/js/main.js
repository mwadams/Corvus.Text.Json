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

  // Sidebar collapsible sections
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
  const activeLink = document.querySelector('.sidebar__link.is-active');
  const docContent = document.querySelector('.doc__content');

  if (activeLink && docContent) {
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

      // Scroll-spy: highlight the heading currently in view
      const tocLinks = subList.querySelectorAll('.sidebar__link--toc');
      const observer = new IntersectionObserver(
        (entries) => {
          entries.forEach((entry) => {
            if (entry.isIntersecting) {
              tocLinks.forEach((l) => l.classList.remove('is-current'));
              const match = subList.querySelector(
                `a[href="#${entry.target.id}"]`
              );
              if (match) match.classList.add('is-current');
            }
          });
        },
        { rootMargin: '-20% 0px -60% 0px', threshold: 0 }
      );

      headings.forEach((h) => observer.observe(h));
    }
  }
});
