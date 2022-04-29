import React from "react";

import classes from "./UserItem.module.css";

import UserItemButtons from "./UserItemButtons";

const UserItem = (props) => {
  return (
    <li className={classes.meal}>
      <div className={classes.content}>
        <h3>{props.fullName}</h3>
        <div className={classes.description}>{props.rating}</div>
      </div>
      <div>
        <UserItemButtons />
      </div>
    </li>
  );
};

export default UserItem;
