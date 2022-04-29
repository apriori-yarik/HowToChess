import React, { useRef } from "react";

import "./LoginForm.css";

import Container from "react-bootstrap/Container";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import authService from "../../services/auth-service";

const LoginForm = () => {
  const emailRef = useRef();
  const passwordRef = useRef();

  const a = () => {
    const email = emailRef.current.value;
    const password = passwordRef.current.value;
    console.log(email);
    console.log(password);
    //authService.login
  };

  return (
    <Container id="main-container" className="d-grid h-100">
      <Form id="sign-in-form" className="text-center p-3 w-100">
        <img
          className="mb-4 bootstrap-logo"
          src="https://iconape.com/wp-content/files/hv/12082/svg/chess-pawn.svg"
          alt="Chess Pawn"
        />
        <h1 className="mb-3 fs-3 fw-normal">Sign in</h1>
        <Form.Group className="mb-3" controlId="sign-in-email-address">
          <Form.Control
            type="email"
            size="lg"
            placeholder="Email address"
            autoComplete="username"
            className="position-relative"
            ref={emailRef}
          />
        </Form.Group>
        <Form.Group className="mb-3" controlId="sign-in-password">
          <Form.Control
            type="password"
            size="lg"
            placeholder="Password"
            autoComplete="current-password"
            className="position-relative"
            ref={passwordRef}
          />
        </Form.Group>
        <div className="d-grid">
          <Button variant="primary" size="lg" onClick={a}>
            Sign in
          </Button>
        </div>
      </Form>
    </Container>
  );
};

export default LoginForm;
