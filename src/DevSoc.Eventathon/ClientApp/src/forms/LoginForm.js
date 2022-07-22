import React, {useCallback, useState} from "react";
import { useForm } from "react-hook-form";
import {useHistory} from "react-router-dom";
import {login, useUser} from "../api/events-endpoint";

export default function LoginForm() {
    const { register, handleSubmit, setError, formState: { errors } } = useForm();
    const { data: user } = useUser();
    const [show,setShow]=useState(false)
    const history = useHistory();

    const onSubmit = useCallback(
        (formValues) => {
            login(formValues.username, formValues.password).then(isLoggedIn => {
                if (isLoggedIn) {
                    history.push('/calendar')
                    
/*                    if (!user) {
                        // show spinner... redirect to login after some amount of time
                        setShow(true)
                    }
                    else{
                        history.push('/calendar')
                    }*/
                    
                } else {
                    setError('auth', { type: 'custom', message: 'Your username or password was incorrect' })
                }
            })
        },
        [setError],
    )

    
    
    return (
        <form className="register-form" onSubmit={handleSubmit(onSubmit)}>
            <input className="form-field" placeholder="N/T Number"
                   {...register("username", { required: true })}
            />
            <input className="form-field" placeholder="Password"
                   type="password"
                   {...register("password", { required: true, minLength: 8 })}
            />
            <button type="submit">Login</button>
            {errors.password && <p> Login unsuccessful</p>}

            {show?
            <div className="mt-4 d-flex justify-content-center">
                <div className="spinner-border text-primary" role="status"></div>
                <span className=" mx-3">Loading...</span>
            </div>:null
            }
            
            
        </form>
    );
}