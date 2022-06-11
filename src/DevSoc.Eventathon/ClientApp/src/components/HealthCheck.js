import React from 'react';
import { useHealthCheck } from '../api/health/health-endpoint';

export const HealthCheck = () => {
  const { status } = useHealthCheck();
  console.log(status);
  return (
    <div>
      <h1>Health Check</h1>
      <p aria-live="polite">Current status: <strong>{JSON.stringify(status)}</strong></p>
    </div>
  );
}