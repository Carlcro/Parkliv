import React from "react";
import PropTypes from "prop-types";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import * as memberActions from "../../actions/membersActions";
import ManageMembersTemplete from "./ManageMembersTemplete.jsx";
import toastr from "toastr";

class CreateMembersPage extends React.Component {
  constructor(props, context) {
    super(props, context);

    this.state = {
      member: Object.assign({}, this.props.member),
      saving: false,
      errors: {}
    };

    this.saveMember = this.saveMember.bind(this);
    this.updateMemberState = this.updateMemberState.bind(this);
  }

  saveMember(event) {
    event.preventDefault();
    this.setState({ saving: true });
    this.props.actions.saveMember(this.state.member);
    this.redirect();
  }

  redirect() {
    this.setState({ saving: false });
    toastr.success("Member saved");
    this.context.router.history.push("/members");
  }

  updateMemberState(member) {
    this.setState({ member: member });
  }

  render() {
    return (
      <div>
        <h1>Create new Member</h1>
        <ManageMembersTemplete
          saveMember={this.saveMember}
          member={this.state.member}
          onChange={this.updateMemberState}
          loading={this.state.saving}
        />
      </div>
    );
  }
}

CreateMembersPage.propTypes = {
  member: PropTypes.object.isRequired,
  actions: PropTypes.object.isRequired
};

CreateMembersPage.contextTypes = {
  router: PropTypes.object
};

function mapStateToProps() {
  let member = { fname: "", lname: "", description: "" };

  return {
    member: member
  };
}

function mapDispatchToProps(dispatch) {
  return {
    actions: bindActionCreators(memberActions, dispatch)
  };
}

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(CreateMembersPage);
