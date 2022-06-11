import React, { useState } from 'react';
import { useHealthCheck } from '../api/health/health-endpoint';

export const HealthCheck = () => {
  const { data: status } = useHealthCheck();
  const isLoading = useState(() => status == null, [status]);

  return (
    <div>
      <h1>Health Check</h1>
      {isLoading ? 
        <p aria-live="polite">Current status: <strong>{status}</strong></p> :
        <p>Loading...</p>
      }
    </div>
  );
}