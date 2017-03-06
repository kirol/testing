# http://stackoverflow.com/questions/40262441/how-to-transform-a-dot-graph-to-json-graph

# Packages needed  :
# sudo aptitude install python-networkx python-pygraphviz
#
# Syntax :
# python dot_to_json_graph.py graph.dot

import networkx as nx
from networkx.readwrite import json_graph

import sys

if len(sys.argv)==1:
  sys.stderr.write("Syntax : python %s dot_file\n" % sys.argv[0])
else:
  #dot_graph = nx.read_dot(sys.argv[1])
  dot_graph = nx.drawing.nx_agraph.read_dot(sys.argv[1])
  print(dot_graph)
