import React from 'react';
import PropTypes from 'prop-types';
import '../../styles/about-page.css';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as memberActions from '../../actions/membersActions';
import { Link } from 'react-router-dom';
import MemberList from '../Member/MemberList';

class MembersPage extends React.Component{
  constructor(props, context) {
    super(props, context);
  }

  render() {
    const {members} = this.props;
    return (
      <div>
        <h1>Members in Parkliv</h1>
        <MemberList members={members}/>
        <h1><Link to={'/CreateMember/'}>Create new member</Link></h1>
      </div>
    );
  }
}

MembersPage.propTypes = {
  members: PropTypes.array.isRequired,
  actions: PropTypes.object.isRequired
};

function mapStateToProps(state) {
  return {
    members: state.members
  };
}

function mapDispatchToProps(dispatch) {
  return {
    actions: bindActionCreators(memberActions, dispatch)
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(MembersPage);
