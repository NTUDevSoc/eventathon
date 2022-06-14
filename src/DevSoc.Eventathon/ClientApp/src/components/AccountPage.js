import React from "react";
import LoginForm from "../forms/LoginForm";
import SignupForm from "../forms/SignupForm";

export const AccountPage = () => {
    return (
        <div>
            <h1><u>Signup!</u></h1>
            <SignupForm />
            
            <hr></hr>
            
            <h1><u>Login!</u></h1>
            <LoginForm />
        </div>
    );
}