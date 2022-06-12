import axios from 'axios';
import useSWR from 'swr';

export const useGetEvent= (id) => {
  const fetcher = url => axios.get(url).then((response) => response.data);
  return useSWR(`/api/events/${id}`, fetcher);
}
  
export const useGetEvents = () => {
  const fetcher = url => axios.get(url).then((response) => response.data);
  return useSWR('/api/events', fetcher);
}

const createEvent = (givenName, givenDescription, givenStart, givenEnd) => {
  const element = document.querySelector('#post-request .article-id');
  const article = {
      name: givenName,
      description: givenDescription,
      start: givenStart,
      end: givenEnd
  };
  axios.post('api/events', article).then(response => element.innerHTML = response.data.id);
}

export function useDeleteEvent() {

}