import React from "react";
import LoginForm from "../forms/LoginForm";
import SignupForm from "../forms/SignupForm";

export const AccountPage = () => {
    return (
        <div className="row justify-content-center">

            <div className="col-md-6">
                <div>
                    <h1 className="mt-5 d-flex justify-content-center"><u>Login!</u></h1>
                    <LoginForm />
                </div>
                
            </div>

            <div className="col-md-6 red-form">
                <div className="right-side">
                    <h1 className="mt-5 d-flex justify-content-center"><u>Signup!</u></h1>
                    <SignupForm />
                </div>
            </div>
        </div>
    );
}
