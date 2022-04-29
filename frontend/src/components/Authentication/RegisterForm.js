import React from "react";

import "./RegisterForm.css";

import Container from "react-bootstrap/Container";
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";

const RegisterForm = () => {
  return (
    <Container id="main-container" className="d-grid h-100">
      <Form id="sign-in-form" className="text-center p-3 w-100">
        <img
          className="mb-4 bootstrap-logo"
          src="https://iconape.com/wp-content/files/hv/12082/svg/chess-pawn.svg"
          alt="Chess Pawn"
        />
        <h1 className="mb-3 fs-3 fw-normal">Register</h1>
        <Form.Group className="mb-3" controlId="sign-in-email-address">
          <Form.Control
            type="email"
            size="lg"
            placeholder="Email address"
            autoComplete="username"
            className="position-relative"
          />
        </Form.Group>
        <Form.Group className="mb-3" controlId="sign-in-password">
          <Form.Control
            type="password"
            size="lg"
            placeholder="Password"
            autoComplete="current-password"
            className="position-relative"
          />
        </Form.Group>
        <Form.Group className="mb-3" controlId="sign-in-fullname">
          <Form.Control
            type="text"
            size="lg"
            placeholder="Full Name"
            autoComplete="current-password"
            className="position-relative"
          />
        </Form.Group>
        <Form.Group className="mb-3" controlId="sign-in-rating">
          <Form.Control
            type="number"
            size="lg"
            placeholder="Rating"
            autoComplete="current-password"
            className="position-relative"
          />
        </Form.Group>
        <div className="d-grid">
          <Button variant="primary" size="lg">
            Register
          </Button>
        </div>
      </Form>
    </Container>
  );
};

export default RegisterForm;
