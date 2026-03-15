/**
 * Corvus.Text.Json Documentation Site — Main JavaScript
 */

// Mobile navigation toggle
document.addEventListener('DOMContentLoaded', () => {
  const menuToggle = document.querySelector('.site-header__menu-toggle');
  const nav = document.querySelector('.site-nav');

  if (menuToggle && nav) {
    menuToggle.addEventListener('click', () => {
      nav.classList.toggle('site-nav--open');
      menuToggle.classList.toggle('site-header__menu-toggle--open');
      menuToggle.setAttribute(
        'aria-expanded',
        menuToggle.getAttribute('aria-expanded') === 'true' ? 'false' : 'true'
      );
    });
  }

  // Sidebar collapsible sections
  const sidebarToggles = document.querySelectorAll('.docs-sidebar__toggle');
  sidebarToggles.forEach((toggle) => {
    toggle.addEventListener('click', () => {
      const section = toggle.closest('.docs-sidebar__section');
      section.classList.toggle('docs-sidebar__section--collapsed');
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
    const button = document.createElement('button');
    button.className = 'code-copy';
    button.textContent = 'Copy';
    button.addEventListener('click', () => {
      navigator.clipboard.writeText(block.textContent).then(() => {
        button.textContent = 'Copied!';
        setTimeout(() => {
          button.textContent = 'Copy';
        }, 2000);
      });
    });
    block.parentElement.style.position = 'relative';
    block.parentElement.appendChild(button);
  });
});
