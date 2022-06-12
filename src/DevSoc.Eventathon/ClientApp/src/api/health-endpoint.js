import axios from 'axios';
import useSWR from 'swr';

export const checkHealth = () => {
    const fetcher = url => axios.get(url).then(response => response.status);
    return useSWR('api/health', fetcher);
  }
  