import React from "react";
import PropTypes from "prop-types";
import MemberForm from "./MemberForm.jsx";

class ManageMembersTemplete extends React.Component {
  constructor(props, context) {
    super(props, context);

    this.state = {
      member: Object.assign({}, this.props.member),
      errors: {}
    };

    this.updateMembersState = this.updateMembersState.bind(this);
  }

  updateMembersState(event) {
    const field = event.target.name;
    let member = this.state.member;
    member[field] = event.target.value;
    return this.props.onChange(member);
  }

  render() {
    return (
      <div>
        <MemberForm
          onSave={this.props.saveMember}
          onChange={this.updateMembersState}
          member={this.state.member}
          errors={this.state.errors}
          loading={this.props.loading}
        />
      </div>
    );
  }
}

ManageMembersTemplete.propTypes = {
  member: PropTypes.object.isRequired,
  saveMember: PropTypes.func.isRequired,
  onChange: PropTypes.func
};

export default ManageMembersTemplete;
