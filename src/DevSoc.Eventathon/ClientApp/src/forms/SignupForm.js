import React, {useCallback} from "react";
import { useForm } from "react-hook-form";
import {createUser} from "../api/events-endpoint";

export default function SignupForm() {

    const { register, handleSubmit, errors, setError } = useForm();

    const onSubmit = useCallback(
        (formValues) => {
            createUser(formValues.username, formValues.password, formValues.displayName).then(isSignedUp => {
                if (!isSignedUp) {
                    setError('auth', { type: 'custom', message: 'Your password was incorrect' })
                }
            })
        },
        [setError],
    )

    return (
        <form className="register-form" onSubmit={handleSubmit(onSubmit)}>
            <input className="form-field" placeholder="Username"
                   {...register("username", { required: true })}
            />
            <input className="form-field" placeholder="Password"
                   type="password"
                   {...register("password", { required: true, minLength: 8 })}
            />
{/*            {errors.password && <p> Password must contain more than seven characters</p>}*/}
    
            <input className="form-field" placeholder="Display name"
                   {...register("displayName", { required: true})}
            />
            <button type="submit">Submit</button>
        </form>
    );
}