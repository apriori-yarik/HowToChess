import React from "react";
import UserItem from "../User/UserItem";

const Ranking = (props) => {
  const users = props.users.sort((a, b) => b.rating - a.rating);

  return (
    <ul>
      {users.map((x) => (
        <UserItem fullName={x.fullName} email={x.email} rating={x.rating} />
      ))}
    </ul>
  );
};

export default Ranking;
