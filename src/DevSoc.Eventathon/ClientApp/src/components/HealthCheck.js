import React from 'react';
import { useHealth } from '../api/health-endpoints';

export const HealthCheck = () => {
  const { data: status } = useHealth();

  return (
    <div className="my-3">
      <h1>Health Check</h1>
      {status !==  null ? 
        <p aria-live="polite">Current status: <strong>{status}</strong></p> :
        <p>Loading...</p>
      }
    </div>
  );
}