import React from "react";
import { useForm } from "react-hook-form";
import {createUser} from "../api/events-endpoint";
import LoginForm from "../forms/LoginForm";

export default function AccountPage() {
    const { register, handleSubmit, formState: { errors } } = useForm();
    
    const onSubmit = (data) => {
        console.log(data);
        createUser(data.username, data.password)
    }

    return (
        <div>
            <h1><u>Signup!</u></h1>
            <form className="register-form" onSubmit={handleSubmit(onSubmit)}>
                <input className="form-field" placeholder="Username"
                       {...register("username", { required: true })}
                />
                <input className="form-field" placeholder="Password"
                       type="password"
                       {...register("password", { required: true, minLength: 8 })}
                />
                {errors.Password && <p> Password must contain more than seven characters</p>}

                <input className="form-field" placeholder="Display name"
                       {...register("displayName", { required: true})}
                />
                <button type="submit">Submit</button>
            </form>
            
            <hr></hr>
            
            <h1><u>Login!</u></h1>
            <LoginForm />
        </div>
    );
}