import React from "react";
import PropTypes from "prop-types";

const SubgroupList = ({ member, subgroups }) => {
  return (
    <div>
      <table className="table">
        <thead>
          <tr>
            <th>Name</th>
            <th>Description</th>
            <th>Admin</th>
          </tr>
        </thead>
      </table>
    </div>
  );
};

SubgroupList.propTypes = {
  member: PropTypes.array.isRequired,
  subgroups: PropTypes.array.isRequired
};

export default SubgroupList;
