import React from "react";
import LoginForm from "../forms/LoginForm";
import SignupForm from "../forms/SignupForm";

export const AccountPage = () => {
    return (
        <div className="container-fluid">
            <div className="row justify-content-center">

                <div className="col-md-6">
                    <h1 className="mt-5 d-flex justify-content-center"><u>Login!</u></h1>
                    <LoginForm />
                </div>

                <div className="col-md-6 red-form">
                    <h1 className="mt-5 d-flex justify-content-center"><u>Signup!</u></h1>
                    <SignupForm />
                </div>
            </div>
        </div>
    );
}
