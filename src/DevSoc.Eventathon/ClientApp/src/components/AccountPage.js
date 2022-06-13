import React from "react";
import { useForm } from "react-hook-form";

export default function AccountPage() {
    const { register, handleSubmit, formState: { errors } } = useForm();
    const onSubmit = data => console.log(data);

    return (
        <form onSubmit={handleSubmit(onSubmit)}>
            <input placeholder="Username"
                   {...register("Username", { required: true })}
            />
            <input placeholder="Password"
                   type="password"
                   {...register("Password", { required: true, minLength: 8 })}
            />
            <input placeholder="Display name"
                   {...register("DisplayName", { required: true, minLength: 8 })}
            />
            <button type="submit">Submit</button>
        </form>
    );
}