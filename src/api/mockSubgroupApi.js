import delay from './delay';

// This file mocks a web API by working with the hard-coded data below.
// It uses setTimeout to simulate the delay of an AJAX call.
// All calls return promises.
const members = [
  {
    id: 'cory-house',
    firstName: 'Cory',
    lastName: 'House'
  },
  {
    id: 'scott-allen',
    firstName: 'Scott',
    lastName: 'Allen'
  },
  {
    id: 'dan-wahlin',
    firstName: 'Dan',
    lastName: 'Wahlin'
  }
];

//This would be performed on the server in a real app. Just stubbing in.
const generateId = (member) => {
  return member.firstName.toLowerCase() + '-' + member.lastName.toLowerCase();
};

class MemberApi {
  static getAllMembers() {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        resolve(Object.assign([], members));
      }, delay);
    });
  }

  static saveMember(member) {
	member = Object.assign({}, member); // to avoid manipulating object passed in.
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        // Simulate server-side validation
        const minMemberNameLength = 3;
        if (member.firstName.length < minMemberNameLength) {
          reject(`First Name must be at least ${minMemberNameLength} characters.`);
        }

        if (member.lastName.length < minMemberNameLength) {
          reject(`Last Name must be at least ${minMemberNameLength} characters.`);
        }

        if (member.id) {
          const existingMemberIndex = members.findIndex(a => a.id == member.id);
          members.splice(existingMemberIndex, 1, member);
        } else {
          //Just simulating creation here.
          //The server would generate ids for new members in a real app.
          //Cloning so copy returned is passed by value rather than by reference.
          member.id = generateId(member);
          members.push(member);
        }

        resolve(member);
      }, delay);
    });
  }

  static deleteMember(memberId) {
    return new Promise((resolve, reject) => {
      setTimeout(() => {
        const indexOfMemberToDelete = members.findIndex(member => {
          member.id == memberId;
        });
        members.splice(indexOfMemberToDelete, 1);
        resolve();
      }, delay);
    });
  }
}

export default MemberApi;
