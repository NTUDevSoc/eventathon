import axios from 'axios';
import useSWR from 'swr';

export function useHealthCheck () {
    const fetcher = url => axios.get(url).then(response => response.status);
    return useSWR('api/health', fetcher);
  }
  