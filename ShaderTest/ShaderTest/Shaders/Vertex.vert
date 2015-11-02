attribute vec3 aVertex;
varying vec3 vPos;
void main()
{
	vPos = aVertex;
	vec4 pos = vec4(aVertex, 1.0);
	gl_Position = pos;

}