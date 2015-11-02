varying vec3 vPos;
uniform float uTime;
void main()
{

	gl_FragColor = vec4(1.0,(sin(vPos.x*10+uTime)+1)*0.5f,(cos(vPos.y*10)+1)*0.5f,0.5);

}