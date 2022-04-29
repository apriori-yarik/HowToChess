import React from "react";
import { Container, Nav, Navbar } from "react-bootstrap";
import { Link } from "react-router-dom";
import authService from "../../services/auth-service";

import "../Authentication/LoginForm.css";
import NavBarLoggedIn from "./NavBarLoggedIn";
import NavBarLoggedOut from "./NavBarLoggedOut";

const NavBar = () => {
  return (
    <>
      <Navbar bg="light">
        <Container>
          <img
            className="bootstrap-logo"
            src="https://iconape.com/wp-content/files/hv/12082/svg/chess-pawn.svg"
            alt="Chess Pawn"
          />
          <Navbar.Brand href="#home">HowToChess</Navbar.Brand>
          <Nav className="me-auto">
            <Nav.Link href="#home">
              <Link className="nav-link" to={"/home"}>
                Home
              </Link>
            </Nav.Link>
            <Nav.Link href="#features">
              <Link className="nav-link" to={"/play-with-ai"}>
                Play With AI
              </Link>
            </Nav.Link>
            <Nav.Link href="#pricing">
              <Link className="nav-link" to={"/puzzles"}>
                Solve puzzles
              </Link>
            </Nav.Link>
            <Nav.Link href="#pricing">
              <Link className="nav-link" to={"/history"}>
                Game History
              </Link>
            </Nav.Link>
            <Nav.Link href="#pricing">
              <Link className="nav-link" to={"/ranking"}>
                Ranking
              </Link>
            </Nav.Link>
          </Nav>
          <Nav className="me-auto">
            {authService.getCurrentUser() && <NavBarLoggedIn />}
            {!authService.getCurrentUser() && <NavBarLoggedOut />}
          </Nav>
        </Container>
      </Navbar>
    </>
  );
};

export default NavBar;
