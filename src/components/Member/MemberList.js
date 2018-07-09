import React from 'react';
import MemberListRow from './MemberListRow';
import PropTypes from 'prop-types';


const MemberList = ({members}) => {
  return (
    <table className="table">
      <thead>
        <tr>
          <th>Name</th>
          <th>Desciption</th>
        </tr>
      </thead>
      <tbody>
      {members.map(member =>
      <MemberListRow key={member.id} member={member}/>
      )}
      </tbody>
    </table>
  );
};

MemberList.propTypes = {
  members: PropTypes.array.isRequired
};

export default MemberList;
