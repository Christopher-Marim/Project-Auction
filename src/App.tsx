import React from 'react';
import { BrowserRouter, Route, Switch } from "react-router-dom";
import { AuthProvider } from './hooks/auth';
import { StateProvider } from './hooks/state';
import { ClientScreen } from './pages/ClientScreen';
import { CurrentAuction } from './pages/CurrentAuction';
import { TradeScreen } from './pages/TradeScreen';

function App() {
  return (
    <BrowserRouter>
      <AuthProvider>
        <StateProvider>
        <Switch>
          <Route  path="/" exact component={ClientScreen} />
          <Route  component={TradeScreen} path="/pages/auctions" />
          <Route  component={CurrentAuction} path="/pages/currentAuction" />
        </Switch>
        </StateProvider>
      </AuthProvider>
    </BrowserRouter>
  );
}

export default App;
