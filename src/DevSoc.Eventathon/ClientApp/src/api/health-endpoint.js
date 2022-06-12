import axios from 'axios';
import useSWR from 'swr';

export const useCheckHealth = () => {
    const fetcher = url => axios.get(url).then(response => response.status);
    return useSWR('api/health', fetcher);
  }
  