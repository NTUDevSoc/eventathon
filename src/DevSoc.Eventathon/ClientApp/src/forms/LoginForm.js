import React, {useCallback} from "react";
import { useForm } from "react-hook-form";
import {login} from "../api/events-endpoint";
import {useHistory} from "react-router-dom";

export default function LoginForm() {
    const { register, handleSubmit, errors, setError } = useForm();
    const history = useHistory();

    const onSubmit = useCallback(
        (formValues) => {
            login(formValues.username, formValues.password).then(isLoggedIn => {
                if (isLoggedIn) {
                    history.push('/calendar')
                } else {
                    setError('auth', { type: 'custom', message: 'Your username or password was incorrect' })
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
{/*            {errors.auth && <b>{errors.auth.message}</b>}*/}
            <button type="submit">Login</button>
        </form>
    );
}