import useSWR from "swr";
import { client } from "./http-helpers";

export const createUser = (username, password) => {
  return client.post('/users', { username, password }).then(response => response.data);
}

export const login = (username, password) => {
  return client.post('/login', { username, password }).then(response => response.status === 200);
}

export const useUser = () => {
  const fetcher = url => client.get(url).then((response) => response.data);
  return useSWR(`/users/current`, fetcher);
}