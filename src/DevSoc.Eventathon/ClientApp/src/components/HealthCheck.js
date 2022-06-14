import React, { useState } from 'react';
import { useCheckHealth } from '../api/health-endpoint';

export const HealthCheck = () => {
  const { data: status } = useCheckHealth();
  const isLoading = useState(() => status == null, [status]);

  return (
    <div className="my-3">
      <h1>Health Check</h1>
      {isLoading ? 
        <p aria-live="polite">Current status: <strong>{status}</strong></p> :
        <p>Loading...</p>
      }
    </div>
  );
}