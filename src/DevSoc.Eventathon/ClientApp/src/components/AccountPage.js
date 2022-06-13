import React from "react";
import { useForm } from "react-hook-form";

export default function AccountPage() {
    const { register, handleSubmit, formState: { errors } } = useForm();
    const onSubmit = data => console.log(data);

    return (
        <form className="register-form" onSubmit={handleSubmit(onSubmit)}>
            <input className="form-field" placeholder="Username"
                   {...register("Username", { required: true })}
            />
            <input className="form-field" placeholder="Password"
                   type="password"
                   {...register("Password", { required: true, minLength: 8 })}
            />
            <input className="form-field" placeholder="Display name"
                   {...register("DisplayName", { required: true})}
            />
            <button type="submit">Submit</button>
        </form>
    );
}