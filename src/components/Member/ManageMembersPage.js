import React from 'react';
import PropTypes from 'prop-types';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as memberActions from '../../actions/membersActions';
import ManageMembersTemplete from './ManageMembersTemplete';


class ManageMembersPage extends React.Component {
    constructor(props, context) {
      super(props, context);

      this.state = {
        member: Object.assign({}, this.props.member),
        errors: {}
      };
      
      this.updateMemberState = this.updateMemberState.bind(this);
      this.updateMember = this.updateMember.bind(this);
      this.deleteMember = this.deleteMember.bind(this);
    }

    componentWillReceiveProps(nextProps){
      if(this.props.member.id != nextProps.member.id){
        this.setState({member: Object.assign({},nextProps.member)})
      }
    }

    updateMemberState(member) {
      this.setState({member: member});
    }
     
    updateMember(event){
      event.preventDefault();
      this.props.actions.updateMember(this.state.member);
      this.redirect();
    }

    deleteMember(event){
      event.preventDefault();
      this.props.actions.deleteMember(this.state.member);
      this.redirect();
    }

    redirect(){
      this.context.router.history.push('/members');
    }

    render() {
      return (      
        <div>
            <h1>Manage Member</h1>
            <ManageMembersTemplete
                          member={this.state.member}
                          onSave={this.updateMember}
                          onChange={this.updateMemberState}
                          errors={this.state.errors} />
             <input 
                type="submit"
                value={'Delete'}
                className="btn btn-primary"
                onClick={this.deleteMember}/>              
        </div>
      );    
  }
}   


ManageMembersPage.propTypes = {
  member: PropTypes.object.isRequired,

};

ManageMembersPage.contextTypes = {
  router: PropTypes.object
};

function getMemberbyId(id, members){
  const member = members.filter(x => x.id == id );
  if (member.length) return member[0];
  return null;
} 

function mapStateToProps(state, ownProps){
  const memberId = ownProps.match.params.id;
  let member = {fname: '', lname: '', description: ''};

  
  if (state.members.length > 0){
    member = getMemberbyId(memberId, state.members);
  }

  return {
    member: member,
  };
}

function mapDispatchToProps(dispatch){
  return {
    actions: bindActionCreators(memberActions, dispatch)
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(ManageMembersPage);


