


float Sphere_float(float3 Centre, float radius, float Point)
{
    float3 dir = Centre - Point;
    float dist = length(dir) - radius;
    return dist;
}