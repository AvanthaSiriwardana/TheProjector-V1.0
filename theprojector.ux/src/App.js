import React from 'react';
import logo from './logo.svg';
import './App.css';

import { SiteNavigation } from './components/SiteNavigation';
import { Home } from "./components/Home";
import { CreatePerson } from "./components/CreatePerson";
import { CreateProject } from "./components/CreateProject";
import { Login } from './components/Login';
import { ListProjects } from './components/ListProjects';

import { BrowserRouter as Router, Route , Switch } from 'react-router-dom';

function App() {
  return (
    <Router>
      <SiteNavigation />
        <Switch>
          <Route path='/' component={Home} exact />
          <Route path='/projector/signin' component={Login} />
          <Route path='/projector/projects' component={ListProjects} exact />
          <Route path='/projector/projects/create' component={CreateProject} />
          <Route path='/projector/persons/create' component={CreatePerson} />
        </Switch>
    </Router>

  );
}

export default App;
