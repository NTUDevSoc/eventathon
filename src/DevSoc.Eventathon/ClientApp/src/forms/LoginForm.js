import React from "react";
import { useForm } from "react-hook-form";
import {createUser} from "../api/events-endpoint";

export default function LoginForm() {
    const { register, handleSubmit, formState: { errors } } = useForm();

    const onSubmit = (data) => {
        console.log(data);
        // createUser(data.username, data.password)
    }

    return (
        <form className="register-form" onSubmit={handleSubmit(onSubmit)}>
            <input className="form-field" placeholder="Username"
                   {...register("username", { required: true })}
            />
            <input className="form-field" placeholder="Password"
                   type="password"
                   {...register("password", { required: true, minLength: 8 })}
            />
            {errors.Password && <p> Password must contain more than seven characters</p>}
            <button type="submit">Login</button>
        </form>
    );
}