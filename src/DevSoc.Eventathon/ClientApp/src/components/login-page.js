import React from 'react'
import { login } from '../api/login-endpoint';

export default function LoginPage() {
  const { register, handleSubmit, setError } = useForm();
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
      <form className='login' onSubmit={handleSubmit(onSubmit)}>
          <input type='text' {...register('username', { required: true })} />
          <input type='password' {...register('password', { required: true })}
          />
          {errors.auth && <p></p>}
          <button type="submit">Login</button>
      </form>
  );
}
