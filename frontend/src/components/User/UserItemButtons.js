import React from "react";

import Button from "../UI/Button";

import classes from "./UserItemButtons.module.css";

const UserItemButtons = () => {
  const onUpdateHandler = () => {};

  const onDeleteHandler = () => {};

  return (
    <div className={classes.buttons}>
      <div>
        <Button onClick={onUpdateHandler}>Edit</Button>
      </div>
      <div>
        <Button onClick={onDeleteHandler}>Delete</Button>
      </div>
    </div>
  );
};

export default UserItemButtons;
