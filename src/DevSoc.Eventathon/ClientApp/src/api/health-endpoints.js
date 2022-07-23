import useSWR from 'swr';
import { client } from './http-helpers';

export const useHealth = () => {
    const fetcher = url => client.get(url).then(response => response.status);
    return useSWR('/health', fetcher);
  }
  