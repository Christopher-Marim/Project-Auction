import React from 'react';
import { BrowserRouter, Route, Switch } from "react-router-dom";
import { AuthProvider } from './hooks/auth';
import { StateProvider } from './hooks/state';
import { ClientScreen } from './pages/ClientScreen';
import { CreateAuction } from './pages/CreateAuction';
import { CreateClient } from './pages/CreateClient';
import { CurrentAuction } from './pages/CurrentAuction';
import { TradeScreen } from './pages/TradeScreen';

function App() {
  return (
    <BrowserRouter>
      <AuthProvider>
        <StateProvider>
        <Switch>
          <Route  path="/" exact component={CreateClient} />
          <Route  component={TradeScreen} path="/pages/auctions" />
          <Route  component={CurrentAuction} path="/pages/currentAuction" />
          <Route  component={CreateAuction} path="/pages/createAuction" />
        </Switch>
        </StateProvider>
      </AuthProvider>
    </BrowserRouter>
  );
}

export default App;
