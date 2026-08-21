(function () {
  'use strict';

  var root = document.documentElement;
  var content = document.getElementById('_content');
  var brand = document.querySelector('.navbar-brand');
  var search = document.querySelector('.navbar-form');

  if (content && content.querySelector('.events-hero')) {
    document.body.classList.add('events-home');
  } else {
    document.body.classList.add('docs-page');
  }

  if (brand && !brand.querySelector('.navbar-brand-text')) {
    var label = document.createElement('span');
    label.className = 'navbar-brand-text';
    label.innerHTML = 'Events Model<small>LIS iLab documentation</small>';
    brand.appendChild(label);
  }

  var savedTheme;
  try { savedTheme = localStorage.getItem('events-model-theme'); } catch (_) { savedTheme = null; }
  var darkPreferred = window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches;
  var theme = savedTheme || (darkPreferred ? 'dark' : 'light');
  root.setAttribute('data-theme', theme);

  if (search) {
    var toggle = document.createElement('button');
    toggle.type = 'button';
    toggle.className = 'theme-toggle';
    toggle.setAttribute('aria-label', theme === 'dark' ? 'Use light theme' : 'Use dark theme');
    toggle.title = toggle.getAttribute('aria-label');
    toggle.textContent = theme === 'dark' ? '☀' : '☾';
    toggle.addEventListener('click', function () {
      theme = root.getAttribute('data-theme') === 'dark' ? 'light' : 'dark';
      root.setAttribute('data-theme', theme);
      toggle.textContent = theme === 'dark' ? '☀' : '☾';
      toggle.setAttribute('aria-label', theme === 'dark' ? 'Use light theme' : 'Use dark theme');
      toggle.title = toggle.getAttribute('aria-label');
      try { localStorage.setItem('events-model-theme', theme); } catch (_) { }
    });
    search.parentNode.insertBefore(toggle, search.nextSibling);
  }

  var namespacePrefix = 'Skyware.Lis.EventsModel';
  var tocLookupAttempts = 0;

  function shortenNamespaceNavigation(toc) {
    var links = toc.querySelectorAll('a:not([data-namespace-shortened])');

    Array.prototype.forEach.call(links, function (link) {
      var fullName = (link.getAttribute('title') || link.textContent || '').replace(/\s+/g, '').trim();
      var shortName;

      if (fullName === namespacePrefix) {
        shortName = 'Core';
      } else if (fullName.indexOf(namespacePrefix + '.') === 0) {
        shortName = fullName.substring(namespacePrefix.length + 1);
      } else {
        return;
      }

      link.setAttribute('title', fullName);
      link.setAttribute('data-namespace-shortened', 'true');
      link.textContent = '';

      shortName.split('.').forEach(function (part, index, parts) {
        link.appendChild(document.createTextNode(part));
        if (index < parts.length - 1) {
          link.appendChild(document.createTextNode('.'));
          link.appendChild(document.createElement('wbr'));
        }
      });
    });
  }

  function observeNamespaceNavigation() {
    var toc = document.getElementById('toc');

    if (!toc) {
      if (tocLookupAttempts++ < 30) {
        window.setTimeout(observeNamespaceNavigation, 100);
      }
      return;
    }

    shortenNamespaceNavigation(toc);
    new MutationObserver(function () {
      shortenNamespaceNavigation(toc);
    }).observe(toc, { childList: true, subtree: true });
  }

  observeNamespaceNavigation();

  function enhanceInheritedMembers() {
    var sections = document.querySelectorAll('.inheritedMembers:not([data-collapsible])');

    Array.prototype.forEach.call(sections, function (section) {
      var heading = section.querySelector('h5');
      var members = Array.prototype.filter.call(section.children, function (child) {
        return child !== heading;
      });

      if (!heading || !members.length) {
        return;
      }

      var details = document.createElement('details');
      details.className = section.className + ' inherited-collapsible';
      details.setAttribute('data-collapsible', 'true');

      var summary = document.createElement('summary');
      var label = document.createElement('span');
      var count = document.createElement('span');
      var body = document.createElement('div');

      label.className = 'inherited-label';
      label.textContent = heading.textContent.trim();
      count.className = 'inherited-count';
      count.textContent = members.length;
      body.className = 'inherited-body';

      summary.appendChild(label);
      summary.appendChild(count);
      members.forEach(function (member) {
        body.appendChild(member);
      });

      details.appendChild(summary);
      details.appendChild(body);
      section.parentNode.replaceChild(details, section);
    });
  }

  enhanceInheritedMembers();
}());
