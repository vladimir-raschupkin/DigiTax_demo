import { useState } from 'react';
import './App.css';

type Tab = 'info' | 'invoices';

function App() {
  const [activeTab, setActiveTab] = useState<Tab>('info');

  return (
    <div className="app-shell">
      <aside className="sidebar">
        <div className="brand">
          <span className="brand-mark">D</span>
          <span className="brand-name">DigiTax</span>
        </div>

        <nav className="sidebar-nav" aria-label="Main navigation">
          <button
            className={`nav-item ${activeTab === 'info' ? 'active' : ''}`}
            onClick={() => setActiveTab('info')}
            type="button"
            aria-current={activeTab === 'info' ? 'page' : undefined}
          >
            <span className="nav-icon" aria-hidden="true">ⓘ</span>
            <span>Info</span>
          </button>
          <button
            className={`nav-item ${activeTab === 'invoices' ? 'active' : ''}`}
            onClick={() => setActiveTab('invoices')}
            type="button"
            aria-current={activeTab === 'invoices' ? 'page' : undefined}
          >
            <span className="nav-icon" aria-hidden="true">▤</span>
            <span>Invoices</span>
          </button>
        </nav>

        <div className="sidebar-footer">© 2025 DigiTax</div>
      </aside>

      <main className="main-content">
        <header className="top-bar">
          <button className="menu-button" type="button" aria-label="Open navigation menu">
            <span aria-hidden="true">☰</span>
          </button>
          <h1>DigiTax</h1>
        </header>

        <div className="content-container">
          <div className="breadcrumb" aria-label="Breadcrumb">
            <span>Home</span>
            <span aria-hidden="true">/</span>
            <strong>{activeTab === 'info' ? 'Info' : 'Invoices'}</strong>
          </div>

          <section className="page-card" aria-labelledby="page-title">
            <h2 id="page-title">{activeTab === 'info' ? 'Info' : 'Invoices'}</h2>
            <div className="placeholder">
              <div className="placeholder-icon" aria-hidden="true">
                {activeTab === 'info' ? 'ⓘ' : '▤'}
              </div>
              <p>This page is ready for content.</p>
              <span>Use this area to add {activeTab === 'info' ? 'application information' : 'invoice management'}.</span>
            </div>
          </section>
        </div>
      </main>
    </div>
  );
}

export default App;
