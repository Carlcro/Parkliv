/* eslint-disable import/no-named-as-default */
import React from "react";
import PropTypes from "prop-types";
import { Switch, NavLink, Route, withRouter } from "react-router-dom";
import HomePage from "./Pages/HomePage.jsx";
import AboutPage from "./Pages/AboutPage.jsx";
import MembersPage from "./Pages/MembersPage.jsx";
import SubgroupPage from "./Pages/SubgroupPage.jsx";
import NotFoundPage from "./Pages/NotFoundPage.jsx";
import ManageMembersPage from "../components/Member/ManageMembersPage.jsx";
import CreateMembersPage from "../components/Member/CreateMembersPage.jsx";
import LoadingSpinner from "../components/common/LoadingSpinner.jsx";
import { connect } from "react-redux";
// This is a class-based component because the current
// version of hot reloading won't hot reload a stateless
// component at the top-level.

class App extends React.Component {
  render() {
    const activeStyle = { color: "blue" };
    return (
      <div>
        <div>
          <NavLink exact to="/" activeStyle={activeStyle}>
            Home
          </NavLink>
          {" | "}
          <NavLink exact to="/members" activeStyle={activeStyle}>
            Members
          </NavLink>
          {" | "}
          <NavLink exact to="subgroup" activeStyle={activeStyle}>
            Subgroups
          </NavLink>
          {" | "}
          <NavLink to="/about" activeStyle={activeStyle}>
            About
          </NavLink>
          {this.props.loading && <LoadingSpinner />}
        </div>
        <Switch>
          <Route exact path="/" component={HomePage} />
          <Route path="/members" component={MembersPage} />
          <Route path="/subgroup" component={SubgroupPage} />
          <Route path="/about" component={AboutPage} />
          <Route path="/createMember/" component={CreateMembersPage} />
          <Route path="/member/:id" component={ManageMembersPage} />
          <Route component={NotFoundPage} />
        </Switch>
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    loading: state.ajaxCallsInProgress > 0
  };
}

App.propTypes = {
  children: PropTypes.element,
  loading: PropTypes.bool.isRequired
};

export default withRouter(connect(mapStateToProps)(App));
