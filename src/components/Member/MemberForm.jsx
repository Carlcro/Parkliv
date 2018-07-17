import React from "react";
import PropTypes from "prop-types";
import TextInput from "../common/TextInput.jsx";

const MemberForm = ({ member, onSave, onChange, loading, errors }) => {
  return (
    <form>
      <TextInput
        name="fname"
        label="First name"
        value={member.fname}
        onChange={onChange}
        error={errors.title}
      />

      <TextInput
        name="lname"
        label="Last name"
        value={member.lname}
        onChange={onChange}
        error={errors.title}
      />

      <TextInput
        name="description"
        label="Description"
        value={member.description}
        onChange={onChange}
        error={errors.description}
      />

      <input
        type="submit"
        disable={loading}
        value={loading ? "Saving..." : "Save"}
        className="btn btn-primary"
        onClick={onSave}
      />
    </form>
  );
};

MemberForm.propTypes = {
  member: PropTypes.object.isRequired
};

export default MemberForm;
