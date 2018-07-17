import React from "react";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";

const MemberListRow = ({ member }) => {
  return (
    <tr>
      <td>
        <Link to={"/member/" + member.id}>
          {member.fname + " " + member.lname}
        </Link>
      </td>
      <td>{member.description}</td>
    </tr>
  );
};

MemberListRow.propTypes = {
  member: PropTypes.object.isRequired
};

export default MemberListRow;
