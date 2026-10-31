---
title: LIS iLab Events Model
description: Event contracts for reliable, real-time laboratory integrations.
---

<div class="events-hero">
  <div class="hero-copy">
    <span class="hero-kicker"><span class="status-dot"></span> Integration reference</span>
    <h1>Every laboratory event.<br><span>One shared language.</span></h1>
    <p>LIS iLab Events Model defines dependable, versioned event contracts for connected laboratory systems — from sample logistics and instruments to visits, payments and national services.</p>
    <div class="hero-actions">
      <a class="button button-primary" href="articles/getting-started.md">Get started <span aria-hidden="true">→</span></a>
      <a class="button button-secondary" href="xref:Skyware.Lis.EventsModel">Explore the API</a>
    </div>
    <div class="hero-meta">
      <span><strong>Real-time</strong> delivery</span>
      <span><strong>Typed</strong> .NET contracts</span>
      <span><strong>Pub/Sub</strong> architecture</span>
    </div>
  </div>
  <div class="event-console" aria-label="Example event stream">
    <div class="console-bar">
      <div class="console-dots"><i></i><i></i><i></i></div>
      <span>live-event-stream</span>
      <span class="live-pill"><i></i> LIVE</span>
    </div>
    <div class="console-body">
      <div class="flow-line"><span class="flow-time">09:42:17</span><span class="flow-icon sample">S</span><span><strong>Sample checked in</strong><small>topic://smp-tracking/check-in</small></span><b>200</b></div>
      <div class="flow-connector"></div>
      <div class="flow-line"><span class="flow-time">09:42:18</span><span class="flow-icon instrument">I</span><span><strong>Instrument order</strong><small>topic://instruments/orders</small></span><b>200</b></div>
      <div class="flow-connector"></div>
      <div class="flow-line"><span class="flow-time">09:44:03</span><span class="flow-icon result">R</span><span><strong>Results updated</strong><small>topic://results</small></span><b>200</b></div>
    </div>
    <div class="console-footer"><span>3 events received</span><span>Latency <strong>24 ms</strong></span></div>
  </div>
</div>

<div class="section-heading">
  <span>BUILT FOR INTEGRATION</span>
  <h2>From event to implementation</h2>
  <p>Everything you need to discover contracts, connect a consumer and build reliable workflows.</p>
</div>

<div class="feature-grid">
  <a class="feature-card" href="articles/intro.md">
    <span class="feature-icon architecture">↗</span>
    <span class="feature-tag">01 · CONCEPTS</span>
    <h3>Understand the architecture</h3>
    <p>Learn how loosely coupled services exchange real-time messages through publish–subscribe channels.</p>
    <strong>Read the introduction <span>→</span></strong>
  </a>
  <a class="feature-card featured" href="articles/getting-started.md">
    <span class="feature-icon quickstart">⌁</span>
    <span class="feature-tag">02 · QUICKSTART</span>
    <h3>Connect your first consumer</h3>
    <p>Install the packages, configure ActiveMQ Artemis and send your first typed event.</p>
    <strong>Start building <span>→</span></strong>
  </a>
  <a class="feature-card" href="articles/addresses.md">
    <span class="feature-icon addresses">⌘</span>
    <span class="feature-tag">03 · REFERENCE</span>
    <h3>Find an event address</h3>
    <p>Browse topics for visits, instruments, payments, sample logistics, NHIS and NRA.</p>
    <strong>Browse addresses <span>→</span></strong>
  </a>
</div>

<div class="model-strip">
  <div><span class="model-mark">EM</span><span><strong>Strongly typed by design</strong><small>Consistent contracts across every connected system</small></span></div>
  <a href="xref:Skyware.Lis.EventsModel">View all namespaces <span>→</span></a>
</div>

