import axios from 'axios';
import useSWR from 'swr';

export const useEvent = (id) => {
  const fetcher = url => axios.get(url).then((response) => response.data);
  return useSWR(`/api/events/${id}`, fetcher);
}
  
export const useEvents = () => {
  const fetcher = url => axios.get(url).then((response) => response.data);
  return useSWR('/api/events', fetcher);
}

export const createEvent = (givenName, givenDescription, givenStart, givenEnd) => {
    const article = {
        name: givenName,
        description: givenDescription,
        start: givenStart,
        end: givenEnd
    };
    return axios.post('api/events', article).then(response => response.status === 200);
}

export const createUser = (username, password, givenDisplayName) => {
    return axios.post('api/users', { username, password}).then(response => response.status === 200);
}

export const login = (username, password) => {
    // API layer, handles nothing except POST request - 200 status code means we logged in successfully
    return axios.post('api/login', { username, password}).then(response => response.status === 200);
}

export function useDeleteEvent() {

}