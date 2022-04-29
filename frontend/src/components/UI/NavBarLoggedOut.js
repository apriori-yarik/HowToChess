import React from "react";
import { Nav } from "react-bootstrap";
import { Link } from "react-router-dom";

const NavBarLoggedOut = () => {
  return (
    <>
      <Nav.Link href="#home">
        <Link className="nav-link" to={"/register"}>
          Register
        </Link>
      </Nav.Link>
      <Nav.Link href="#features">
        <Link className="nav-link" to={"/login"}>
          Login
        </Link>
      </Nav.Link>
    </>
  );
};

export default NavBarLoggedOut;
