import useSWR from 'swr';
import { client } from './http-helpers';

export const useEvent = (id) => {
  const fetcher = url => client.get(url).then((response) => response.data);
  return useSWR(`/events/${id}`, fetcher);
}
  
export const useEvents = () => {
  const fetcher =  url => client.get(url).then((response) => response.data);
  return useSWR('/events', fetcher);
}

export const createEvent = (name, description, start, end) => {
    const eventDefinition = {
        name,
        description,
        start,
        end
    };

    return client.post('/events', eventDefinition).then(response => response.data);
}
