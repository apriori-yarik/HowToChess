import React from "react";
import { Nav } from "react-bootstrap";
import { Link } from "react-router-dom";

const NavBarLoggedIn = () => {
  return (
    <>
      <Nav.Link href="#home">
        <Link className="nav-link" to={"/profile"}>
          Profile
        </Link>
      </Nav.Link>
      <Nav.Link href="#features">
        <Link className="nav-link" to={"/logout"}>
          Logout
        </Link>
      </Nav.Link>
    </>
  );
};

export default NavBarLoggedIn;
